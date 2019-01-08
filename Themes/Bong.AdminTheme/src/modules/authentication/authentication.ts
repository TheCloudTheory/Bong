import * as Bong from '../../modules/bong';

export = Authentication;

namespace Authentication {
    export const Module = 'authentication';

    export type Entity = Bong.EntityModule & {
        authenticationType: AuthenticationType
    }

    export enum AuthenticationType {
        Basic
    }
}