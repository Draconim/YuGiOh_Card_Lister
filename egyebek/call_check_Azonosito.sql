set serveroutput on;
declare 
    v_call_szorny_azonosito int;
    v_szorny_azonosito szornyek.azonosito%type := 'ETCO-EN054';
    v_call_varazs_azonosito int;
    v_varazs_azonosito varazs.azonosito%type := 'MP20-EN181';
    v_call_csapda_azonosito int;
    v_csapda_azonosito csapda.azonosito%type := 'MP20-EN133';
begin
	v_call_szorny_azonosito := sf_check_szorny_aznosito(v_szorny_azonosito);
    
    IF v_call_szorny_azonosito= 1 THEN
        DBMS_OUTPUT.PUT_LINE('A megadott lap azonosítója helyes: '||v_szorny_azonosito);
    ELSE 
        DBMS_OUTPUT.PUT_LINE('A megadott lap azonosítója helytelen: '||v_szorny_azonosito);    
    END IF;

    v_call_varazs_azonosito := sf_check_varazs_aznosito(v_varazs_azonosito);
    
    IF v_call_varazs_azonosito= 1 THEN
        DBMS_OUTPUT.PUT_LINE('A megadott lap azonosítója helyes: '||v_varazs_azonosito);
    ELSE 
        DBMS_OUTPUT.PUT_LINE('A megadott lap azonosítója helytelen: '||v_varazs_azonosito);    
    END IF;

    v_call_csapda_azonosito := sf_check_csapda_aznosito(v_csapda_azonosito);
    
    IF v_call_csapda_azonosito= 1 THEN
        DBMS_OUTPUT.PUT_LINE('A megadott lap azonosítója helyes: '||v_csapda_azonosito);
    ELSE 
        DBMS_OUTPUT.PUT_LINE('A megadott lap azonosítója helytelen: '||v_csapda_azonosito);    
    END IF;
END;