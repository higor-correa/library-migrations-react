import { List, ListItem, ListItemText } from "@material-ui/core";
import React from "react";
import { NavLink } from "react-router-dom";
import routes from "../routes";
import "./menu.css";

const Menu = () => {
    return (
        <List>
            {routes.map((prop, key) => {
                return (
                    <NavLink
                        to={prop.path}
                        activeClassName="active"
                        key={key}>
                        <ListItem>
                            <ListItemText primary={prop.menuDescription}/>
                        </ListItem>
                    </NavLink>)
            })}
        </List>
    );
}

export default Menu;