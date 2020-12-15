drop table varazslap;
create table varazslap
(
    azonosito char(9) not null,
    nev varchar2(30) not null,
    leiras varchar2(300),
    magic_type varchar2(11) not null,
    rarity varchar2(15) not null,
    quantity int not null,
    
    constraint pk_varazs primary key(azonosito),
    constraint ch_magic_type check(magic_type in ('normal', 'quick-play', 'continous', 'field', 'equip', 'ritual')),
    constraint ch_varazs_rarity check(rarity in ('common', 'rare', 'super-rare', 'ultra-rare', 'secrete-rare'))
);
    
