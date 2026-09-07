# Vague B — Fiches joueur WoW + hub jeu

Pont identité Platform ↔ microservice jeu, fiche joueur WoW publique, rails sur la home WoW. Les guildes, le mur modéré et le LFG complet restent en **Vague C** ; le layout widgets personnalisable est une sous-étape de B (lib partagée).

## Décisions verrouillées

- **Clé publique fiche jeu** : `Player.PublicId` (GUID), pas l’`Id` Platform.
- **Lien depuis le profil Platform** : `/users/:platformPublicId` → résolution WoW → `/world-of-warcraft/players/:playerPublicId`.
- **Identité WoW** : `Player.IdKeycloak` + `Player.PlatformUserPublicId` (index uniques), `IdUser` = `Platform.User.Id` renseigné au `Load`.
- **Mute LFG** : bannière + masquage UI côté shell (session Platform) en B ; enforcement Consumer WoW ↔ Platform en C.
- **Widgets** : package DevKit `@bari77/gc-widgets` (grille + hosts) partagé shell / remotes — spike après B1.

## B1 — Identité & fiche joueur WoW

- [x] Migration `Player` : `IdKeycloak`, `PlatformUserPublicId` (index uniques filtrés)
- [x] `Players.Load` (auth) : get-or-create par Keycloak + ids Platform
- [x] `Players.Get` (public) : fiche par `Player.PublicId`
- [x] `Players.Resolve` (public) : `{ platformUserPublicId }` → `{ playerPublicId? }`
- [x] `Players.Update` (auth) : présentations IRL / IG, propre fiche uniquement
- [x] Routes WoW : `/world-of-warcraft/sheet` (ma fiche), `/world-of-warcraft/players/:publicId`
- [x] Profil Platform public : section « Jeux » avec lien WoW si fiche existante

## B2 — Personnages (CRUD minimal)

- [ ] `Characters` : Create / Get / List (par joueur) / Update / Delete
- [ ] UI fiche : liste persos, formulaire création / édition
- [ ] Personnage principal (`Main`) — un seul par joueur

## B3 — Médias profil & layout widgets

- [ ] `PlayerPicture`, `PlayerVideo`, `PlayerStream` — list + upload metadata
- [ ] Colonne `LayoutJson` sur `Player` (grille widgets)
- [ ] Spike `@bari77/gc-widgets` : `WidgetGridHost`, `WidgetColumnSpan`, éditeur propriétaire
- [ ] Widgets initiaux : bio, persos, médias, stats

## B4 — Home WoW (rails)

- [x] `HomeFeed.Get` : derniers LFG actifs, persos créés, fiches joueur, événements à venir
- [x] Rail LFG : tchat global chronologique + SignalR (`/hubs/wow-lfg`) en temps réel
- [x] `LfgAds.Create` (auth) : titre, corps, kind, expiration
- [x] MSW handlers pour dev standalone (`useMocks: true`)

## Gateway (Vague B)

| Resource | Public | Private (auth) |
|----------|--------|----------------|
| Players | Get, Resolve | Load, Update |
| HomeFeed | Get | — |
| LfgAds | ListRecent | Create |
| Characters | Get | Create, Update, Delete, List |

## Hors scope B

- Guildes, mur de guilde, modération jeu — Vague C
- Événements in-game (inscription perso) — Vague D
- API Blizzard / import auto — jamais au lancement

## Matrice d’accès profil

| Visiteur | Profil Platform | Fiche WoW |
|----------|-----------------|-----------|
| Anonyme | identité publique | fiche publique si existe |
| Connecté | + amis / DM / report | + lien depuis profil Platform |
| Propriétaire | édition profil Platform | `Load` + `Update` fiche + futur layout |
