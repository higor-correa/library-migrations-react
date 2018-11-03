import Home from "./pages/home/home.js"

const routes = [
    {
        path: "/",
        component: Home,
        menuDescription: "Home"
    },
    {
        path: "/teste",
        component: Home,
        menuDescription: "Teste"
    },
    {
        component: Home,
        menuDescription: "Teste",
        links: [
            {
                path: "/submenu",
                component: Home,
                menuDescription: "Submenu - 1",
            },
            {
                path: "/submenu2",
                component: Home,
                menuDescription: "Submenu - 2",
            },
            {
                component: Home,
                menuDescription: "Submenu - 3",
                links: [
                    {
                        path: "/submenu3",
                        component: Home,
                        menuDescription: "SubSubmenu - 1",
                    },
                ]
            }
        ]
    }
];

export default routes;