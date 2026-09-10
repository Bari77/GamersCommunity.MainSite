import { Component, inject } from "@angular/core";
import { RouterLink } from "@angular/router";
import { UsersStore } from "@features/users/stores/users.store";
import { NbButtonModule, NbIconModule, NbSpinnerModule } from "@nebular/theme";
import { SkeletonComponent } from "@bari77/gc-ui";
import { UserHandleComponent } from "@shared/components/user-handle/user-handle.component";
import { Friend } from "../../models/friend.model";
import { FriendsStore } from "../../stores/friends.store";
import { MessengerStore } from "../../stores/messenger.store";

@Component({
    standalone: true,
    selector: "app-friends",
    imports: [NbButtonModule, NbIconModule, NbSpinnerModule, SkeletonComponent, UserHandleComponent, RouterLink],
    templateUrl: "./friends.component.html",
    styleUrl: "./friends.component.scss",
})
export class FriendsComponent {
    public readonly requestPlaceholders = [0, 1];
    public readonly friendPlaceholders = [0, 1, 2];
    public readonly friendsStore = inject(FriendsStore);
    public readonly usersStore = inject(UsersStore);
    private readonly messengerStore = inject(MessengerStore);

    public message(friend: Friend): void {
        this.messengerStore.openThread(this.friendsStore.peerId(friend));
    }
}
