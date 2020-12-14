drop table szornyek;
CREATE TABLE szornyek(
    azonosito varchar2(10) not null,
    nev varchar2(30) not null,
    leiras varchar2(300),
    monster_card_type varchar2(10) not null,
    monster_level int,
    monster_attribute varchar2(15) not null,
    monster_type varchar2(10) not null,
    attack int not null,
    defense int,
    link_level int,
    rarity varchar2(15) not null,
    quantity int not null,

    
    constraint pk_szornyek primary key(azonosito),
    constraint ch_monster_card_type check(monster_card_type in ('normal', 'effect', 'synchro', 'xyz', 'link', 'ritual')),
    constraint ch_attribute check(monster_attribute in ('light', 'dark', 'earth', 'water', 'wind', 'fire', 'divine_beast')),
    constraint ch_rarity check(rarity in ('common', 'rare', 'super_rare', 'ultra_rare', 'secrete_rare'))
);
