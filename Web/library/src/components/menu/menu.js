// import { List, ListItem, ListItemText } from "@material-ui/core";
import React, { Component } from "react";
import { NavLink } from "react-router-dom";
import routes from "../../routes";
import "./menu.css";

class Menu extends Component {
    state = {
        routes: [...routes]
    };

    getInternMenus(menu) {
        let menus = [];
        if (menu.links) {
            for (let i in menu.links) {
                let aux = menu.links[i];
                menus.push(aux)
                if (aux.links)
                    menus.concat(this.getInternMenus(aux));
            }
        }
        return menus;
    }

    menuClicked(menu) {
        menu.active = !menu.active;
        if (!menu.active && menu.links) {
            this.getInternMenus(menu).map(x => x.active = false);
        }

        this.setState({ ...this.state });
    }

    renderMenuLink(menu, key) {

        return (
            <li key={key}>
                <NavLink 
                    exact
                    to={menu.path}
                    className="menu-item"
                    activeClassName="menu-active"
                    key={menu.key}>
                    {menu.menuDescription}
                </NavLink>
            </li>
        );
    }

    renderMenu(menu, key) {
        if (menu.path)
            return this.renderMenuLink(menu, key)
        else {
            return (
                <li key={key} >
                    <span
                        href="#"
                        onClick={() => this.menuClicked(menu)}>
                        {menu.menuDescription}
                    </span>

                    <ul className="sub-menu"
                        hidden={!menu.active}>
                        {menu.links.map((menu, key2) => this.renderMenu(menu, `${key2}-${key}`))}
                    </ul>
                </li>
            );
        }
    }

    render() {
        return (
            <ul className="menu">
                {this.state.routes.map((menu, key) => this.renderMenu(menu, key))}
            </ul>
        );
    }
}

export default Menu;