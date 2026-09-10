import { DatePipe } from "@angular/common";
import { Component, inject } from "@angular/core";
import { Router } from "@angular/router";
import { SkeletonComponent } from "@bari77/gc-ui";
import { CommunityEvent } from "../../models/event.model";
import { EventsStore } from "../../stores/events.store";

@Component({
    standalone: true,
    selector: "app-events-list",
    imports: [DatePipe, SkeletonComponent],
    templateUrl: "./events-list.component.html",
    styleUrl: "./events-list.component.scss",
})
export class EventsListComponent {
    public readonly eventsStore = inject(EventsStore);
    public readonly cardPlaceholders = [0, 1, 2, 3, 4, 5];
    public readonly descriptionPlaceholders = [0, 1, 2];
    private readonly router = inject(Router);

    public open(event: CommunityEvent): void {
        this.router.navigate(["/events", event.publicId]);
    }
}
