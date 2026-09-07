import { inject, Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { UsersStore } from "@features/users/stores/users.store";
import { NbAuthService } from "@nebular/auth";
import { map, Observable, of, switchMap, take } from "rxjs";

@Injectable()
export class UnauthGuard implements CanActivate {
    private readonly authService = inject(NbAuthService);
    private readonly usersStore = inject(UsersStore);
    private readonly router = inject(Router);

    public canActivate(): Observable<boolean> {
        return this.authService.isAuthenticated().pipe(
            take(1),
            switchMap((authenticated) => {
                if (!authenticated) {
                    return of(true);
                }

                if (this.usersStore.isLoggedIn()) {
                    void this.router.navigate(["/home"]);
                    return of(false);
                }

                return this.authService.logout("authentik").pipe(map(() => true));
            }),
        );
    }
}
