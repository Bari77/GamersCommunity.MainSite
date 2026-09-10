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
                data: { breadcrumb: $localize`:@@core.breadcrumb.moderation.users:Users` },
                providers: [StaffUsersStore],
                loadComponent: () =>
                    import("./pages/staff-users/staff-users.component").then((m) => m.StaffUsersComponent),
            },
            {
                path: "users/:publicId",
                data: { breadcrumb: $localize`:@@core.breadcrumb.moderation.user:User` },
                providers: [StaffUserDetailStore],
                loadComponent: () =>
                    import("./pages/staff-user-detail/staff-user-detail.component").then(
                        (m) => m.StaffUserDetailComponent,
                    ),
            },
            {
                path: "reports",
                data: { breadcrumb: $localize`:@@core.breadcrumb.moderation.reports:Reports` },
                providers: [ReportsStore],
                loadComponent: () =>
                    import("./pages/staff-reports/staff-reports.component").then((m) => m.StaffReportsComponent),
            },
        ],
    },
];
