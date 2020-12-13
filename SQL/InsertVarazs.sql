create or replace procedure spInsert_varazs(
    p_azonosito             in varazslap.azonosito%type,
    p_nev                   in varazslap.nev%type,
    p_leiras                in varazslap.leiras%type,
    p_magic_type            in varazslap.magic_type%type,
    p_rarity                in varazslap.rarity%type,
    p_quantity              in varazslap.quantity%type,
    --p_out_rowcnt out int
)
authid definer
as
    v_check_azonosito int;
begin
    --p_out_rowcnt := 0;
    v_check_azonosito := sf_check_varazs_azonosito(p_azonosito);
    if v_check_azonosito = 1 then
        insert into varazslap
            (azonosito, nev, leiras, magic_type, rarity, quantity)
        values
            (p_azonosito, p_nev, p_leiras, p_magic_type, p_rarity, p_quantity);
        --p_out_rowcnt := SQL%rowcount;
        commit;
    end if;
end spInsert_varazs;

