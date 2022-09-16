using Microsoft.AspNetCore.Http;

namespace StatisticVisualizerLib.Services.ExcelFileService
{
    /// <summary>
    /// Сервис работы с эксель файлами
    /// </summary>
    public interface IExcelFileService
    {
        /// <summary>
        /// Загрузить файл в БД <br/>
        /// <i>Прим.: проверка на эксель-файл встроена в метод<i/>
        /// <param name="file">Файл</param>
        /// <returns>(Количество обработанных строк, количество успешно обработанных строк, сообщение об ошибке)</returns>
        (int allRows, int succesRows, string error) UploadToDb(IFormFile file);

        /// <summary>
        /// Убедиться что файл - эксель
        /// </summary>
        /// <param name="file">Файл</param>
        /// <exception cref="NotExcelFileException">Если файл не эксель</exception>
        public void EnsureExcelFile(IFormFile file);
    }
}
