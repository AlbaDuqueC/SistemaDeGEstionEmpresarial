// src/data/database/AzureConnection.ts

/**
 * Configuración de la conexión a Azure
 */
export class AzureConnection {
    
    /**
     * URL base de Azure Functions
     */
    private static readonly BASE_URL: string = 'https://signalrchat20260115133542-dzc0arewgxbrh5gu.spaincentral-01.azurewebsites.net/api';
    
    /**
     * Obtiene la URL base de Azure
     * @returns URL base configurada
     */
    public static getBaseUrl(): string {
        return this.BASE_URL;
    }
}