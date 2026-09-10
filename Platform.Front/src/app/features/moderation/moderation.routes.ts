import { Routes } from "@angular/router";
import { staffGuard } from "@core/guards/staff.guard";
import { ReportsStore } from "./stores/reports.store";
import { StaffUserDetailStore } from "./stores/staff-user-detail.store";
import { StaffUsersStore } from "./stores/staff-users.store";

export const moderationRoutes: Routes = [
    {
        path: "",
        canActivate: [staffGuard],
        children: [
            { path: "", pathMatch: "full", redirectTo: "users" },
            {
                path: "users",
                providers: [StaffUsersStore],
                loadComponent: () =>
                    import("./pages/staff-users/staff-users.component").then((m) => m.StaffUsersComponent),
            },
            {
                path: "users/:publicId",
                providers: [StaffUserDetailStore],
                loadComponent: () =>
                    import("./pages/staff-user-detail/staff-user-detail.component").then(
                        (m) => m.StaffUserDetailComponent,
                    ),
            },
            {
                path: "reports",
                providers: [ReportsStore],
                loadComponent: () =>
                    import("./pages/staff-reports/staff-reports.component").then((m) => m.StaffReportsComponent),
            },
        ],
    },
];
