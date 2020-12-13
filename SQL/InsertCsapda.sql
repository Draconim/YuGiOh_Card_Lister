create or replace procedure spInsert_csapda(
    p_azonosito             in csapdalap.azonosito%type,
    p_nev                   in csapdalap.nev%type,
    p_leiras                in csapdalap.leiras%type,
    p_trap_type             in csapdalap.trap_type%type,
    p_rarity                in csapdalap.rarity%type,
    p_quantity              in csapdalap.quantity%type
    --p_out_rowcnt out int
)
authid definer
as
    v_check_azonosito int;
begin
    --p_out_rowcnt := 0;
    v_check_azonosito := sf_check_trap_azonosito(p_azonosito);
    if v_check_azonosito = 1 then
        insert into csapdalap
            (azonosito, nev, leiras, trap_type, rarity, quantity)
        values
            (p_azonosito, p_nev, p_leiras, p_trap_type, p_rarity, p_quantity);
        --p_out_rowcnt := SQL%rowcount;
        commit;
    end if;
end spInsert_csapda;

