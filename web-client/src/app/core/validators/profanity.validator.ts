import {AbstractControl, ValidationErrors, ValidatorFn} from '@angular/forms';
import { Filter } from 'bad-words';

export function profanityValidator(): ValidatorFn {
    return (control:AbstractControl): ValidationErrors | null => {
        const filter = new Filter();
        return filter.isProfane(control.value) ? {profanity: true} : null;
    };
}