export interface Album {
    id?:String;
    nome?:String;    
    musicas?:Musica[];
}

export interface Musica {
    id?:String;
    nome?:String;
    duracao?:String;
}