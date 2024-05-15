import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { TransportContainerService } from '../../services/TransportContainer.service';
import { InstructionService } from '../../services/Instruction.service';

import { TransportContainer } from '../../models/TransportContainer.model';
import { Instruction } from '../../models/Instruction.model';

@Component({
  selector: 'app-add-transport-container',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './add-transport-container.component.html',
  styleUrl: './add-transport-container.component.css'
})
export class AddTransportContainerComponent {
CurentDate=new Date();
  transportContainer: TransportContainer = {
    instructionId: 0,
    clientRef: '',
    containerNumber: '',
    dateScheduled: this.CurentDate.toISOString().substring(0, 10),
    dateTimeDelivered:'',
    deliveryAddress: '',
    pickupAddress: '',
    pickupDateTime:'',
    transporter: '',
    vehicleReg: '',

  };
  instructionList: Instruction[] = [];
  submitted = false;

  constructor(private transportContainerService: TransportContainerService, private instructionService: InstructionService) { }
  ngOnInit(): void {
    console.log(this.CurentDate.getUTCDate()+'/'+this.CurentDate.getUTCMonth()+"/"+this.CurentDate.getUTCFullYear())
    console.log(this.CurentDate.getUTCDate())
    this.getInstruction();
  }
  saveTransportContainer(): void {
    const data = {
      InstructionId: this.transportContainer.instructionId,
      ClientRef: this.transportContainer.clientRef,
      ContainerNumber: this.transportContainer.containerNumber,
      DateScheduled: this.transportContainer.dateScheduled,
      DateTimeDelivered: this.transportContainer.dateTimeDelivered,
      DeliveryAddress: this.transportContainer.deliveryAddress,
      PickupAddress: this.transportContainer.pickupAddress,
      pickupDateTime: this.transportContainer.pickupDateTime,
      Transporter: this.transportContainer.transporter,
      VehicleReg: this.transportContainer.vehicleReg,


    };

    this.transportContainerService.create(data).subscribe({
      next: (res) => {
        console.log(res);
        if (res.data == false) {
          alert(res.message);
        }else{
        this.submitted = true;
        this.getInstruction();
      }
      },
      error: (e) => console.error(e)
    });
    
  }
  selectInstruction() {
    
    var id = this.transportContainer.instructionId
    if(id){
      debugger;
    var instruction = this.instructionList.find(item => item.id == id)
    this.transportContainer.clientRef = instruction?.clientRef
    this.transportContainer.deliveryAddress = instruction?.deliveryAddress
    this.transportContainer.pickupAddress = instruction?.pickupAddress
  }
  }
  getInstruction() {
    //debugger;
    this.instructionService.getAll().subscribe({
      next: (res) => {
        // debugger;
        console.log(res.data);
        this.instructionList = res.data;
        //this.submitted = true;
      }
      //error: (e) => console.error(e)
    });

  }

  newTransportContainer(): void {
    this.submitted = false;
    this.transportContainer = {
      instructionId: 0,
      clientRef: '',
      containerNumber: '',
      dateScheduled: this.CurentDate.toISOString().substring(0, 10),
      dateTimeDelivered: '',
      deliveryAddress: '',
      pickupAddress: 'Pending',
      pickupDateTime: '',
      transporter: '',
      vehicleReg: '',
    };
  }

}
