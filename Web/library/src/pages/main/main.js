
import React, { Component } from "react";
import { Route, Switch } from "react-router";
import Grid from "@material-ui/core/Grid";
import Menu from "../../components/menu/menu.js";
import routes from "../../routes.js";


const route = (
    <Switch>
        {routes.map((prop, key) => {
            return <Route path={prop.path} component={prop.component} key={key} />
        })};
    </Switch>
);

class Main extends Component {
    render() {
        return (
            <Grid container spacing={0}>
                <Grid item md={2}>
                    <Menu />
                </Grid>
                <Grid item md={8}>
                    {route}
                </Grid>
            </Grid >
        );
    };
}

export default Main