import { Component } from '@angular/core';
import { Instruction } from '../../models/Instruction.model';
import { InstructionService } from '../../services/Instruction.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-instruction',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './add-instruction.component.html',
  styleUrl: './add-instruction.component.css'
})
export class AddInstructionComponent {
  CurentDate = new Date();
  instruction: Instruction = {
    instructionDate: this.CurentDate.toISOString().substring(0, 10),
    clientName: '',
    bookingRef: '',
    clientRef: '',
    deliveryAddress: '',
    pickupAddress: '',
    status: 'Pending',
    qty: 0
  };
  submitted = false;

  constructor(private tutorialService: InstructionService) { }

  saveInstruction(): void {
    const data = {
      InstructionDate: this.instruction.instructionDate,
      ClientName: this.instruction.clientName,
      BookingRef: this.instruction.bookingRef,
      ClientRef: this.instruction.clientRef,
      DeliveryAddress: this.instruction.deliveryAddress,
      PickupAddress: this.instruction.pickupAddress,
      Status: this.instruction.status,
      Qty: this.instruction.qty

    };

    this.tutorialService.create(data).subscribe({
      next: (res) => {
        console.log(res);
        if (res.data == false) {
          alert(res.message);
        }else{
        this.submitted = true;
      }
      },
      error: (e) => console.error(e)
    });
  }

  newInstruction(): void {
    this.submitted = false;
    this.instruction = {
      instructionDate: '',
      clientName: '',
      bookingRef: '',
      clientRef: '',
      deliveryAddress: '',
      pickupAddress: '',
      status: 'Pending',
      qty: 0
    };
  }
}
