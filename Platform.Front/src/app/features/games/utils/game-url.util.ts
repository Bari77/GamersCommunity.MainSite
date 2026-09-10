/**
 * Segment d'API du microservice d'un jeu, tel que routé par la Gateway : `/world-of-warcraft` → `worldofwarcraft`.
 */
export function toGameApiSegment(urlValue: string): string {
    return urlValue.replace(/^\/+|\/+$/g, "").replace(/-/g, "");
}

/**
 * Racine de routage front d'un jeu, avec un slash de tête garanti : `world-of-warcraft` → `/world-of-warcraft`.
 */
export function toGameRootPath(urlValue: string): string {
    return `/${urlValue.replace(/^\/+|\/+$/g, "")}`;
}
