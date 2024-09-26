import {AbstractControl, ValidationErrors, ValidatorFn} from '@angular/forms';

export function checkValidUcEmail(): ValidatorFn {
    return (control:AbstractControl) : ValidationErrors | null => {

        const value = control.value;

        if (!value) {
            return null;
        }
        const isAValidUcEmailAddress = value.endsWith('@mail.uc.edu') || value.endsWith('@ucmail.uc.edu');
        if (!isAValidUcEmailAddress) {
            return {validUcEmail: true};
        }
        return null;

    }
}