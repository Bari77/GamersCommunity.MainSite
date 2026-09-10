import { Resource } from "@angular/core";

/**
 * Utilitaires pour les resources Angular.
 */
export class ResourceUtils {
    /**
     * Indique qu'aucune donnée serveur n'est encore disponible et qu'une requête est prévue ou en cours.
     *
     * Contrairement à `isLoading()`, couvre le statut `idle` du premier cycle de détection de
     * changement, pendant lequel la vue afficherait sinon un contenu vide. Exclut en revanche
     * `reloading`, où la valeur précédente reste disponible : la remplacer par un squelette
     * masquerait une donnée déjà affichée.
     */
    public static isPending(resource: Resource<unknown>): boolean {
        const status = resource.status();
        return status === "idle" || status === "loading";
    }
}
