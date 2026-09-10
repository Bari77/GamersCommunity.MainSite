import { loadRemoteModule } from "@angular-architects/native-federation-v4";
import { inject } from "@angular/core";
import { Routes } from "@angular/router";
import { NbToastrService } from "@nebular/theme";

export async function loadRemoteRoutes(
    remoteName: string,
    exposedModule: string,
    exportName: string,
): Promise<Routes> {
    const toastr = inject(NbToastrService);

    try {
        const remote = (await loadRemoteModule(remoteName, exposedModule)) as Record<string, unknown>;
        const routes = remote[exportName];
        if (!Array.isArray(routes)) {
            throw new Error(`Remote "${remoteName}" did not export routes as "${exportName}".`);
        }
        return routes as Routes;
    } catch (error) {
        console.error(`[federation] Failed to load remote "${remoteName}"`, error);
        const message =
            typeof $localize === "function"
                ? $localize`:@@core.federation.loadError:Could not load the game module. Is the game Front running?`
                : "Could not load the game module. Is the game Front running?";
        const title =
            typeof $localize === "function"
                ? $localize`:@@core.federation.loadErrorTitle:Game unavailable`
                : "Game unavailable";
        toastr.danger(message, title, { duration: 8_000 });
        throw error;
    }
}
