import { Injectable } from "@angular/core";
import { BaseService } from "@shared/services/base.service";
import { map, Observable } from "rxjs";

export interface WowPlayerResolveResultDto {
    playerPublicId: string | null;
    hasSheet: boolean;
}

export interface WowPlayerResolveResult {
    playerPublicId: string | null;
    hasSheet: boolean;
}

@Injectable({ providedIn: "root" })
export class WowPlayersService extends BaseService {
    public constructor() {
        super("/worldofwarcraft/Players");
    }

    public resolve(platformUserPublicId: string): Observable<WowPlayerResolveResult> {
        return this.http
            .post<WowPlayerResolveResultDto>(this.getURL("actions/Resolve"), { platformUserPublicId })
            .pipe(map((dto) => ({ playerPublicId: dto.playerPublicId, hasSheet: dto.hasSheet })));
    }
}
