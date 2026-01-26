// src/data/repositories/PersonaRepoAzure.ts
import { Persona } from "../../domain/entities/Persona";
import { IRepositoryPersonas } from "../../domain/interfaces/IPersonaRepo";
import { injectable } from "inversify";
import { AzureConnection } from "../database/AzureConnection";

@injectable()
export class PersonaRepoAzure implements IRepositoryPersonas {

    /**
     * Get del listado completo de Personas desde Azure Functions
     * @returns Devuelve un listado de Personas obtenido desde Azure
     */
    public async getListadoCompletoPersonas(): Promise<Persona[]> {
        try {
            const response = await fetch(`${AzureConnection.getBaseUrl()}/personas`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                }
            });

            if (!response.ok) {
                throw new Error(`Error HTTP: ${response.status}`);
            }

            const data = await response.json();
            
            return data.map((item: any) => new Persona(
                item.id,
                item.nombre,
                item.apellido,
                item.telefono,
                item.direccion,
                item.foto,
                new Date(item.fechaNacimiento),
                item.IdDepartamento
            ));

        } catch (error) {
            console.error('Error al obtener personas desde Azure:', error);
            return [];
        }
    }

    /**
     * Obtiene una persona por su ID desde Azure
     * @param id ID de la persona a buscar
     * @returns Devuelve la persona encontrada o null
     */
    async getPersonaById(id: number): Promise<Persona | null> {
        try {
            const response = await fetch(`${AzureConnection.getBaseUrl()}/personas/${id}`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                }
            });

            if (!response.ok) {
                if (response.status === 404) {
                    return null;
                }
                throw new Error(`Error HTTP: ${response.status}`);
            }

            const data = await response.json();
            
            return new Persona(
                data.id,
                data.nombre,
                data.apellido,
                data.telefono,
                data.direccion,
                data.foto,
                new Date(data.fechaNacimiento),
                data.IdDepartamento
            );

        } catch (error) {
            console.error(`Error al obtener persona con ID ${id}:`, error);
            return null;
        }
    }

    /**
     * Crea una nueva persona en Azure
     * @param persona Persona a crear
     * @returns Devuelve la persona creada con su ID asignado
     */
    async createPersona(persona: Persona): Promise<Persona | null> {
        try {
            const body = {
                nombre: persona.nombre,
                apellido: persona.apellido,
                telefono: persona.telefono,
                direccion: persona.direccion,
                foto: persona.foto,
                fechaNacimiento: persona.fechaNacimiento.toISOString(),
                IdDepartamento: persona.IdDepartamento
            };

            const response = await fetch(`${AzureConnection.getBaseUrl()}/personas`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                },
                body: JSON.stringify(body)
            });

            if (!response.ok) {
                throw new Error(`Error HTTP: ${response.status}`);
            }

            const data = await response.json();
            
            return new Persona(
                data.id,
                data.nombre,
                data.apellido,
                data.telefono,
                data.direccion,
                data.foto,
                new Date(data.fechaNacimiento),
                data.IdDepartamento
            );

        } catch (error) {
            console.error('Error al crear persona:', error);
            return null;
        }
    }

    /**
     * Actualiza una persona existente en Azure
     * @param persona Persona con los datos actualizados
     * @returns Devuelve true si se actualizó correctamente
     */
    async updatePersona(persona: Persona): Promise<boolean> {
        try {
            const body = {
                nombre: persona.nombre,
                apellido: persona.apellido,
                telefono: persona.telefono,
                direccion: persona.direccion,
                foto: persona.foto,
                fechaNacimiento: persona.fechaNacimiento.toISOString(),
                IdDepartamento: persona.IdDepartamento
            };

            const response = await fetch(`${AzureConnection.getBaseUrl()}/personas/${persona.id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                },
                body: JSON.stringify(body)
            });

            return response.ok;

        } catch (error) {
            console.error('Error al actualizar persona:', error);
            return false;
        }
    }

    /**
     * Elimina una persona de Azure
     * @param id ID de la persona a eliminar
     * @returns Devuelve true si se eliminó correctamente
     */
    async deletePersona(id: number): Promise<boolean> {
        try {
            const response = await fetch(`${AzureConnection.getBaseUrl()}/personas/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                }
            });

            return response.ok;

        } catch (error) {
            console.error('Error al eliminar persona:', error);
            return false;
        }
    }
}