import { Game } from "./game.model";

export interface GamePlayerResolveResult {
    playerPublicId: string | null;
    hasSheet: boolean;
}

export interface GamePlayerSheet {
    game: Game;
    typeLabel: string;
    playerPublicId: string;
}
