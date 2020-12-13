create or replace procedure spInsert_szornyek(
    p_azonosito             in szornyek.azonosito%type,
    p_nev                   in szornyek.nev%type,
    p_leiras                in szornyek.leiras%type,
    p_monster_card_type     in szornyek.monster_card_type%type,
    p_monster_level         in szornyek.monster_level%type,
    p_monster_attribute     in szornyek.monster_attribute%type,
    p_monster_type          in szornyek.monster_type%type,
    p_attack                in szornyek.attack%type,
    p_defense               in szornyek.defense%type,
    p_link_level            in szornyek.link_level%type,
    p_rarity                in szornyek.rarity%type,
    p_quantity              in szornyek.quantity%type
    --p_out_rowcnt out int
)
--set serveroutput ON;
authid definer
as
    v_check_azonosito int;
begin
    --p_out_rowcnt := 0;
    v_check_azonosito := sf_check_szorny_azonosito(p_azonosito);
    if v_check_azonosito = 1 then
        insert into szornyek
            (azonosito, nev, leiras, monster_card_type, monster_level, monster_attribute, monster_type, attack, defense, link_level, rarity, quantity)
        values
            (p_azonosito, p_nev, p_leiras, p_monster_card_type, p_monster_level, p_monster_attribute, p_monster_type, p_attack, p_defense, p_link_level, p_rarity, p_quantity);
        --p_out_rowcnt := SQL%rowcount;
        commit;
    --else
        --DBMS_OUTPUT.PUT_LINE("Hiba! Rossz az azonosító!");
    end if;
end spInsert_szornyek;
