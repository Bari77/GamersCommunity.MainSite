import { Component, signal } from "@angular/core";
import { RouterOutlet } from "@angular/router";
import { SkeletonComponent } from "@bari77/gc-ui";

@Component({
    standalone: true,
    selector: "app-game-remote-shell",
    imports: [RouterOutlet, SkeletonComponent],
    templateUrl: "./game-remote-shell.component.html",
    styleUrl: "./game-remote-shell.component.scss",
})
export class GameRemoteShellComponent {
    public readonly cardPlaceholders = [0, 1, 2, 3];
    public readonly pending = signal(true);

    public onChildActivated(): void {
        queueMicrotask(() => this.pending.set(false));
    }
}
