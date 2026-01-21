import 'reflect-metadata';
import { Container } from 'inversify';
import { PeopleListVM } from '../ui/ViewModel/PeopleListVM';

// Crea el contenedor
const container = new Container();

// Bindea el ViewModel
container.bind(PeopleListVM).toSelf();

export { container };