drop table csapdalap;
create table csapdalap
(
    azonosito char(9) not null,
    nev varchar2(30) not null,
    leiras varchar2(300),
    trap_type varchar2(10) not null,
    rarity varchar2(15) not null,
    quantity int not null,
    
    constraint pk_csapdalap primary key(azonosito),
    constraint ch_trap_type check(trap_type in ('normal', 'continous', 'counter')),
    constraint ch_csapda_rarity check(rarity in ('common', 'rare', 'super-rare', 'ultra-rare', 'secrete-rare'))
);
    
