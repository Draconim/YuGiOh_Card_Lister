drop table szornyek;
CREATE TABLE szornyek(
    azonosito char(9) not null,
    nev varchar2(30) not null,
    leiras varchar2(300),
    szorny_type varchar2(10) not null,
    monster_level int,
    monster_attribute varchar2(15) not null,
    monster_type varchar2(10) not null,
    attack int not null,
    defense int,
    link_level int,
    rarity varchar2(15) not null,
    quantity int not null,
 
    
    constraint pk_szornyek primary key(azonosito),
    constraint ch_szorny_tipus check(szorny_type in ('normal', 'effect', 'synchro', 'xyz', 'link', 'ritual')),
    constraint ch_attribute check(monster_attribute in ('light', 'dark', 'earth', 'water', 'wind', 'fire', 'divine-beast')),
    constraint ch_rarity check(rarity in ('common', 'rare', 'super-rare', 'ultra-rare', 'secrete-rare'))
);