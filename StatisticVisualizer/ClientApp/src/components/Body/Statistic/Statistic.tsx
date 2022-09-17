import React, { useEffect, useRef, useState } from 'react';
import { ApiViolaTricolor, StatisticModel, PersonModel } from '../../../api';

const Statistic: React.FC = () => {
    const api = useRef(new ApiViolaTricolor());

    const [statistic, setStatistic] = useState<StatisticModel>();

    useEffect(() => {
        api.current.statistic(0, true)
            .then(s => {
                setStatistic((prev) => s ?? prev)
            })
            .catch(e => {
                console.log(e)
            })
    }, []);

    return (
        <>
            <form method="post" encType="multipart/form-data">
                <p><input type="file" name="file" /></p>
                <p><input type="submit" value="Загрузить" /></p>
            </form>
            <div>
                <table>
                    <tr>
                        <td>
                            <table className="table" style={{ 'width': '50vw' }}>
                                <thead className="text-white" style={{ 'backgroundColor': '#4DE382' }}>
                                    <tr>
                                        <th>Имя</th>
                                        <th>Город</th>
                                        <th>Пол</th>
                                        <th>Возраст</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {
                                        statistic?.people?.map(p =>
                                            <tr>
                                                <td>{p.name}</td>
                                                <td>{p.city}</td>
                                                <td>{(p.isMale ? "М" : "Ж")}</td>
                                                <td>{p.age}</td>
                                            </tr>
                                        )
                                    }
                                </tbody>
                                <tfoot className="btn-group">
                                    {/*for (let i = 0; i <= (statisticpageInfop.totalPages ?? 0); i++)
                            {
                                var classStr = Model?.PageInfo?.PageNumber == i ? "btn btn-default selected btn-primary" : "btn btn-default";
                                var style = Model?.PageInfo?.PageNumber == i ? "background-color: #148F2A" : "";
                                <a className=@classStr style=@style asp-area="" asp-controller="Statistic" asp-action="Index" asp-route-pageNumber=@i asp-route-isOnlyMale=@Model?.IsOnlyMale>@i</a>
                            }*/}
                                </tfoot>
                            </table>
                        </td>
                        <td>

                        </td>
                    </tr>
                </table>
            </div>
        </>
    )
}

export default Statistic