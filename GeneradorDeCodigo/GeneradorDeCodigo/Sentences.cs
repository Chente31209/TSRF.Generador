using System;
using System.Collections.Generic;
using System.Text;

namespace GeneradorDeCodigo
{
    public static class Sentences
    {
        public static string ColumnAll()
        {
            string Sentecia = @"SELECT
                            R.RDB$RELATION_NAME,
                              R.RDB$FIELD_NAME,
                              R.RDB$FIELD_SOURCE,
                              F.RDB$FIELD_LENGTH,
                              F.RDB$FIELD_TYPE,
                              F.RDB$FIELD_SCALE,
                              F.RDB$FIELD_SUB_TYPE
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
    }
}
