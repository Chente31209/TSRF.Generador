﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GeneradorDeCodigo
{
    public static class Sentences
    {
        public static string ColumnAllOld()
        {
            string Sentecia = @"SELECT
                            R.RDB$RELATION_NAME,
                              R.RDB$FIELD_NAME,
                              R.RDB$FIELD_SOURCE,
                              F.RDB$FIELD_LENGTH,
                              F.RDB$FIELD_TYPE,
                              F.RDB$FIELD_SCALE,
                              F.RDB$FIELD_SUB_TYPE,
                              F.RDB$NULL_FLAG                 
                            FROM
                              RDB$RELATION_FIELDS R
                              JOIN RDB$FIELDS F
                                ON F.RDB$FIELD_NAME = R.RDB$FIELD_SOURCE
                              JOIN RDB$RELATIONS RL
                                ON RL.RDB$RELATION_NAME = R.RDB$RELATION_NAME
                            WHERE
                              COALESCE(R.RDB$SYSTEM_FLAG, 0) = 0
                              AND
                              COALESCE(RL.RDB$SYSTEM_FLAG, 0) = 0
                              AND
                              RL.RDB$VIEW_BLR IS NULL
                            ORDER BY
                              R.RDB$RELATION_NAME,
                              R.RDB$FIELD_POSITION";

            return Sentecia;
        }
        public static string ColumnAll()
        {
            string Sentecia = @"SELECT
RF.RDB$RELATION_NAME,
RF.RDB$FIELD_NAME FIELD_NAME,
CASE F.RDB$FIELD_TYPE
WHEN 7 THEN
CASE F.RDB$FIELD_SUB_TYPE
WHEN 0 THEN 'SMALLINT'
WHEN 1 THEN 'NUMERIC(' || F.RDB$FIELD_PRECISION || ', ' || (-F.RDB$FIELD_SCALE) || ')'
WHEN 2 THEN 'DECIMAL'
END
WHEN 8 THEN
CASE F.RDB$FIELD_SUB_TYPE
WHEN 0 THEN 'INTEGER'
WHEN 1 THEN 'NUMERIC(' || F.RDB$FIELD_PRECISION || ', ' || (-F.RDB$FIELD_SCALE) || ')'
WHEN 2 THEN 'DECIMAL'
END
WHEN 9 THEN 'QUAD'
WHEN 10 THEN 'FLOAT'
WHEN 12 THEN 'DATE'
WHEN 13 THEN 'TIME'
WHEN 14 THEN 'CHAR(' || (TRUNC(F.RDB$FIELD_LENGTH / CH.RDB$BYTES_PER_CHARACTER)) || ') '
WHEN 16 THEN
CASE F.RDB$FIELD_SUB_TYPE
WHEN 0 THEN 'BIGINT'
WHEN 1 THEN 'NUMERIC(' || F.RDB$FIELD_PRECISION || ', ' || (-F.RDB$FIELD_SCALE) || ')'
WHEN 2 THEN 'DECIMAL'
END
WHEN 27 THEN 'DOUBLE'
WHEN 35 THEN 'TIMESTAMP'
WHEN 37 THEN 'VARCHAR(' || (TRUNC(F.RDB$FIELD_LENGTH / CH.RDB$BYTES_PER_CHARACTER)) || ')'
WHEN 40 THEN 'CSTRING' || (TRUNC(F.RDB$FIELD_LENGTH / CH.RDB$BYTES_PER_CHARACTER)) || ')'
WHEN 45 THEN 'BLOB_ID'
WHEN 261 THEN 'BLOB SUB_TYPE ' || F.RDB$FIELD_SUB_TYPE
ELSE 'RDB$FIELD_TYPE: ' || F.RDB$FIELD_TYPE || '?'
END FIELD_TYPE,
IIF(COALESCE(RF.RDB$NULL_FLAG, 0) = 0, NULL, 'NOT NULL') FIELD_NULL,
CH.RDB$CHARACTER_SET_NAME FIELD_CHARSET,
DCO.RDB$COLLATION_NAME FIELD_COLLATION,
COALESCE(RF.RDB$DEFAULT_SOURCE, F.RDB$DEFAULT_SOURCE) FIELD_DEFAULT,
F.RDB$VALIDATION_SOURCE FIELD_CHECK,
RF.RDB$DESCRIPTION FIELD_DESCRIPTION
FROM RDB$RELATION_FIELDS RF
JOIN RDB$FIELDS F ON (F.RDB$FIELD_NAME = RF.RDB$FIELD_SOURCE)
LEFT OUTER JOIN RDB$CHARACTER_SETS CH ON (CH.RDB$CHARACTER_SET_ID = F.RDB$CHARACTER_SET_ID)
LEFT OUTER JOIN RDB$COLLATIONS DCO ON ((DCO.RDB$COLLATION_ID = F.RDB$COLLATION_ID) AND (DCO.RDB$CHARACTER_SET_ID = F.RDB$CHARACTER_SET_ID))

ORDER BY RF.RDB$RELATION_NAME,RF.RDB$FIELD_POSITION;";

            return Sentecia;
        }
    }
}
