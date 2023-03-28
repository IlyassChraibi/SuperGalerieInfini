export class RegisterDTO {
    /**
     *
     */
    constructor( public userName: string,
        public email: string,
        public password: string,
        public passwordConfirm: string) {

    }
}
