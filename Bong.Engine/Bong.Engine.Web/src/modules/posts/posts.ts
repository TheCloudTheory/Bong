import * as Bong from '../../modules/bong';

export = Posts;

namespace Posts {
    export const Module = 'posts';

    export type Entity = Bong.EntityModule & {
        title: string,
        url: string,
        body: string,
        subtitle: string
    }
}