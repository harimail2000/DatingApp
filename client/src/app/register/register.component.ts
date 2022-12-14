import { AccountService } from './../_services/account.service';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();

  model : any=  {};

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
  }

  register()
  {
    this.accountService.regsiter(this.model).subscribe({
      next: () =>  {
        this.cancel();
      },
      error: error => console.log(error),

    })
  }

  cancel()
  {
    console.log("Cancelled");
    this.cancelRegister.emit(false);
  }

}
