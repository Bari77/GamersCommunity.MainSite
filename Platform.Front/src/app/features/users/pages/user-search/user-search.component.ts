import { Component, inject, OnInit } from "@angular/core";
import { ActivatedRoute, RouterLink } from "@angular/router";
import { SkeletonComponent } from "@bari77/gc-ui";
import { UserHandleComponent } from "@shared/components/user-handle/user-handle.component";
import { UserDirectoryStore } from "../../stores/user-directory.store";

@Component({
    standalone: true,
    selector: "app-user-search",
    imports: [RouterLink, SkeletonComponent, UserHandleComponent],
    templateUrl: "./user-search.component.html",
    styleUrl: "./user-search.component.scss",
})
export class UserSearchComponent implements OnInit {
    public readonly directoryStore = inject(UserDirectoryStore);
    public readonly resultPlaceholders = [0, 1, 2, 3, 4];
    private readonly route = inject(ActivatedRoute);

    public ngOnInit(): void {
        this.route.queryParamMap.subscribe((params) => {
            this.directoryStore.search(params.get("q") ?? "");
        });
    }
}
