create or replace function sf_check_varazs_azonosito
(
    p_azonosito in varazslap.azonosito%type
)
return int
deterministic
as
    v_azonosito_char char(1);
    v_i int;
begin
    if p_azonosito is null then
        return 0;
    end if;

    if length(trim(p_azonosito)) = 10 then
        v_i := 1;
        while v_i <= 2 loop
            v_azonosito_char := substr(p_azonosito, v_i, 1);
            if not (ascii('A') <= ascii(v_azonosito_char) and ascii(v_azonosito_char) <= ascii('Z')) then
                return 0;            
            end if;
            v_i := v_i + 1;
        end loop;
        while v_i <= 4 loop
            v_azonosito_char := substr(p_azonosito, v_i, 1);
            if not (ascii('A') <= ascii(v_azonosito_char) and ascii(v_azonosito_char) <= ascii('Z')) or (ascii('0') <= ascii(v_azonosito_char) and ascii(v_azonosito_char) <= ascii('9')) then
                return 0;            
            end if;
            v_i := v_i + 1;
        end loop;

        v_azonosito_char := substr(p_azonosito, 5,1);
        if (v_azonosito_char = '-') then
            v_azonosito_char := substr(p_azonosito, 6, 1);
            if(v_azonosito_char = 'E') then
                v_azonosito_char := substr(p_azonosito, 7, 1);
                if(v_azonosito_char = 'N') then
                    v_i := 8;
                    while v_i <= 10 loop
                        v_azonosito_char := substr(p_azonosito, v_i, 1);
                        if not (ascii('0') <= ascii(v_azonosito_char) and ascii(v_azonosito_char) <= ascii('9')) then
                            return 0;            
                        end if;
                        v_i := v_i + 1;
                    end loop;
                    return 1;
                end if;
                return 0;
            end if;
            return 0;        
        end if;
        return 0;    
    end if;
    return 0;
end sf_check_varazs_azonosito;
