import { Container } from "inversify";
import "reflect-metadata";
import { PersonaRepoAzure } from "../data/repositories/PersonaRepositoryAzure";

import { PeopleListVM } from '../ui/ViewModel/PeopleListVM';
import { TYPES } from "./types";


const container = new Container();


// Vinculamos la interfaz con su implementación concreta
container.bind<PersonaRepoAzure>(TYPES.IRepositoryPersonas).to(PersonaRepoAzure);
container.bind<PeopleListVM>(TYPES.IndexVM).to(PeopleListVM);
export { container };


