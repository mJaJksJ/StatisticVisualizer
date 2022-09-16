import React from 'react';

const Upload: React.FC = () => {
    return (
        <>
            <div className="text-center">
                <h1 className="display-4">Загрузка Excel файла</h1>
                <p>
                    <h3>
                        Допустимые форматы:<br />
                    </h3>
                    <i>
                        .xls, .xlsx
                    </i>
                </p>
                <p>
                    В таблице должны быть столбцы с именем, городом, полом и возрастом.
                    Для определения принадлежности столбцов в первой строке таблицы должны быть ячейки с названиями <b>Имя</b>, <b>Город</b>, <b>Пол</b>, <b>Возраст</b> <br />
                    <i>
                        * Пол - имеет значения "М" или "Ж" <br />
                        * Возраст - целое число
                    </i>
                </p>
                <form method="post" encType="multipart/form-data">
                    <p><input type="file" name="file" /></p>
                    <p><input type="submit" value="Загрузить" /></p>
                    <p>
                        @if(Model != null)
                        {
                            <span>Файл <b>@Model.FileName</b><br /></span>
                @if (string.IsNullOrEmpty(Model.Error))
                        {
                            <span>Всего строк обработано: @Model.TotalProcessedRows<br />Успешно: @Model.SuccesedProcessedRows</span>
                        }
                        else
                        {
                            <span><b>Error:</b>@Model.Error</span>
                        }
            }
                    </p>
                </form>
            </div>
        </>
    )
}

export default Upload