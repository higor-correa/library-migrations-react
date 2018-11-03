import Home from "./pages/home/home.js"

const routes = [
    {
        path: "/",
        component: Home,
        menuDescription: "Home",
        icon: "home"
    },
    {
        path: "/teste",
        component: Home,
        menuDescription: "Teste 2",
        icon: "class",
    },
    {
        component: Home,
        menuDescription: "Teste 3",
        icon: "build",
        links: [
            {
                path: "/submenu",
                component: Home,
                menuDescription: "Submenu - 1",
                icon: "backup",
            },
            {
                path: "/submenu2",
                component: Home,
                menuDescription: "Submenu - 2",
                icon: "account_circle",
            },
            {
                component: Home,
                menuDescription: "Submenu - 3",
                icon: "extension",
                links: [
                    {
                        path: "/submenu3",
                        component: Home,
                        menuDescription: "SubSubmenu - 1",
                        icon: "face",
                    },
                ]
            }
        ]
    }
];

export default routes;