/// <reference types="@angular/localize" />

import { bootstrapApplication } from "@angular/platform-browser";
import { appConfig } from "./app/app.config";
import { AppComponent } from "./app/app.component";

function removeBootstrapSplash(): void {
    const splash = document.getElementById("app-splash");
    if (!splash) {
        return;
    }

    splash.classList.add("is-hidden");
    window.setTimeout(() => splash.remove(), 220);
}

bootstrapApplication(AppComponent, appConfig)
    .then(() => removeBootstrapSplash())
    .catch((err) => {
        removeBootstrapSplash();
        console.error(err);
    });
