import { Component } from '@angular/core';
import { AbstractControl, AsyncValidatorFn, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { finalize, map } from 'rxjs';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent {
  errors :string[] | null = null;

  constructor(
    private fb: FormBuilder,
    private accountService: AccountService,
    private router: Router
  ) {}

  complexPassword =/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
 
  registerForm = this.fb.group({
    displayName: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    password: [
      '',
      [Validators.required,
      Validators.pattern(this.complexPassword)],
    ],
    confirmPassword:[
      '',
      [Validators.required,
      Validators.pattern(this.complexPassword)],
    ],

    phoneNumber:[
      '', [Validators.required,Validators.minLength(10),Validators.maxLength(10)]
    ]
  });

  onSubmit() {
    this.accountService.register(this.registerForm.value).subscribe({
      next: () => this.router.navigateByUrl('/shop'),
      error:error => this.errors =error.errors
    });
  }

  validateEmailNotTaken():AsyncValidatorFn{
    return (control:AbstractControl) => {

      return this.accountService.checkEmailExists(control.value).pipe(
        map(result => {
            console.log(result);
           return result ? {emailexists : true}:null
        })
       
      )
    }
  }

  get password(){return this.registerForm.get("password")}

  get confirmPassword(){return this.registerForm.get("confirmPassword")}

}
