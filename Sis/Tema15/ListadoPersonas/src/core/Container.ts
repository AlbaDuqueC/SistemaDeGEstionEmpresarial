import { Container } from "inversify";
import "reflect-metadata";
import { PersonasRepo } from "../data/repositories/PersonaRepo";
import { PersonasRepo100 } from "../data/repositories/PersonaRepo100";
import { PeopleListVM } from '../ui/ViewModel/PeopleListVM';
import { TYPES } from "./types";


const container = new Container();


// Vinculamos la interfaz con su implementación concreta
container.bind<PersonasRepo>(TYPES.IRepositoryPersonas).to(PersonasRepo);
container.bind<PeopleListVM>(TYPES.IndexVM).to(PeopleListVM);
export { container };


