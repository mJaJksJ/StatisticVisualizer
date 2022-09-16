import React, { useRef, useState } from 'react';
import { ApiViolaTricolor, IUploadModel, FileParameter } from '../../../api';

const Upload: React.FC = () => {
    const api = useRef(new ApiViolaTricolor());
    const [uploadModel, setUploadModel] = useState<IUploadModel>();
    const [file, setFile] = useState<File>();

    return (
        <>
            <div className="text-center">
                <h1 className="display-4">Загрузка Excel файла</h1>
                <p>
                    <b>
                        Допустимые форматы:<br />
                    </b>
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
                <form method='POST' action='api/v1/upload' encType='multipart/form-data'>
                    <p><input type="file" name="file" onChange={e => { setFile(e.target.files ? e.target.files[0] : {} as File) }} /></p>
                    <p><input style={{ 'backgroundColor': '#148F2A' }} type='submit' className="mt-2 text-white" value='Загрузить' /></p>
                    <p>
                        {
                            !!uploadModel
                                ? <>
                                    <span>Файл <b>{uploadModel.fileName}</b><br /></span>
                                    {
                                        uploadModel.error
                                            ? <span><b>Error:</b>{uploadModel.error}</span>
                                            : < span>Всего строк обработано: {uploadModel.totalProcessedRows}<br />Успешно: {uploadModel.succesedProcessedRows}</span>
                                    }
                                </>
                                : null
                        }
                    </p>
                </form>
            </div>
        </>
    )
}

export default Upload

function sleep(arg0: number) {
    throw new Error('Function not implemented.');
}

