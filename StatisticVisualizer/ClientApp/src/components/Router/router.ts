import Upload from "../Body/Upload/Upload"

export const publicRoutes = [
    { path: '/', component: Upload, exact: true, },
    { path: '/Upload', component: Upload, exact: true },
]
