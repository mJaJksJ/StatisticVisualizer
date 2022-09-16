import React, { useEffect } from "react";
import { Route, Switch } from "react-router-dom";
import { publicRoutes } from "./router";

const AppRouter: React.FC = () => {
    return (

        <Switch>
            {publicRoutes.map(route =>
                <Route
                    component={route.component}
                    path={route.path}
                    exact={route.exact}
                    key={route.path}
                />
            )}
        </Switch>

    );
};

export default AppRouter;