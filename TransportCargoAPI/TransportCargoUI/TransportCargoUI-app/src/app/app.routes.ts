import { RouterModule,Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { AddInstructionComponent } from './components/add-instruction/add-instruction.component';
import { AddTransportContainerComponent } from './components/add-transport-container/add-transport-container.component';

export const routes: Routes = [
    { path: '', redirectTo: 'add-instruction', pathMatch: 'full' },
    { path: 'add-instruction', component: AddInstructionComponent },
    { path: 'add-transport-container', component: AddTransportContainerComponent }

];

// @NgModule({
//     imports: [RouterModule.forRoot(routes)],
//     exports: [RouterModule]
//   })
//   export class AppRoutingModule { 

//   }