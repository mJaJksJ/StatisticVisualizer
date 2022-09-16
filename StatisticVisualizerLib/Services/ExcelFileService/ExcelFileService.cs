using Microsoft.AspNetCore.Http;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using StatisticVisualizerLib.Database;
using StatisticVisualizerLib.Database.Entities;
using StatisticVisualizerLib.Exceptions;

namespace StatisticVisualizerLib.Services.ExcelFileService
{
    /// <inheritdoc cref="IExcelFileService"/>
    public class ExcelFileService : IExcelFileService
    {
        private readonly string[] _excelExtensions = new[] { ".xls", ".xlsx" };
        private readonly DatabaseContext _context;

        private int _nameIndex;
        private int _cityIndex;
        private int _isMaleIndex;
        private int _ageIndex;

        /// <summary>
        /// .ctor
        /// </summary>
        public ExcelFileService(DatabaseContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public (int allRows, int succesRows, string error) UploadToDb(IFormFile file)
        {
            try
            {
                EnsureExcelFile(file);
            }
            catch (NotExcelFileException e)
            {
                return (0, 0, e.Message);
            }

            var sheet = InitSheet(file);
            var headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;

            // определение столбцов с нужными данными
            for (var i = 0; i < cellCount; i++)
            {
                var cell = headerRow.GetCell(i);

                if (cell == null || string.IsNullOrWhiteSpace(cell.ToString()))
                {
                    continue;
                }
                else
                {
                    switch (cell.ToString())
                    {
                        case "Имя":
                            _nameIndex = i;
                            break;
                        case "Город":
                            _cityIndex = i;
                            break;
                        case "Пол":
                            _isMaleIndex = i;
                            break;
                        case "Возраст":
                            _ageIndex = i;
                            break;
                        default:
                            continue;
                    }
                }
            }

            var successCount = 0;
            for (var i = 1; i <= sheet.LastRowNum; i++)
            {
                var row = sheet.GetRow(i);
                if (AddRowToDb(row))
                {
                    successCount++;
                }
            }

            return (sheet.LastRowNum, successCount, "");
        }

        /// <inheritdoc/>
        public void EnsureExcelFile(IFormFile file)
        {
            if (!_excelExtensions.Contains(Path.GetExtension(file?.FileName ?? ".").ToLower()))
            {
                throw new NotExcelFileException(file?.FileName ?? "");
            }
        }

        private bool AddRowToDb(IRow row)
        {
            if (row == null || row.Cells.All(d => d.CellType == CellType.Blank))
            {
                return false;
            }

            var name = row.GetCell(_nameIndex).ToString();
            var city = row.GetCell(_cityIndex).ToString();

            bool isMale;
            switch (row.GetCell(_isMaleIndex).ToString())
            {
                case "М":
                    isMale = true;
                    break;
                case "Ж":
                    isMale = false;
                    break;
                default:
                    return false;
            }

            if (!int.TryParse(row.GetCell(_ageIndex).ToString(), out var age))
            {
                return false;
            }

            int cityId;
            var cityEntity = _context.Cities.FirstOrDefault(_ => _.Name == city);
            if (cityEntity is null)
            {
                _context.Cities.Add(new City { Name = city });
                cityId = _context.SaveChanges();
            }
            else
            {
                cityId = cityEntity.Id;
            }

            _context.People.Add(new Person
            {
                Name = name,
                CityId = cityId,
                IsMale = isMale,
                Age = age
            });
            _context.SaveChanges();

            return true;
        }

        private static ISheet InitSheet(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName).ToLower();

            if (extension.ToLower() == ".xls")
            {
                HSSFWorkbook hssfwb;
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    ms.Position = 0;
                    hssfwb = new HSSFWorkbook(ms);
                }

                return hssfwb.GetSheetAt(0);
            }
            else
            {
                XSSFWorkbook xssfwb;
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    ms.Position = 0;
                    xssfwb = new XSSFWorkbook(ms);
                }

                return xssfwb.GetSheetAt(0);
            }
        }
    }
}
