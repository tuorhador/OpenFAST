/*

The contents of this file are subject to the Mozilla Public License
Version 1.1 (the "License"); you may not use this file except in
compliance with the License. You may obtain a copy of the License at
http://www.mozilla.org/MPL/

Software distributed under the License is distributed on an "AS IS"
basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
License for the specific language governing rights and limitations
under the License.

The Original Code is OpenFAST.

The Initial Developer of the Original Code is The LaSalle Technology
Group, LLC.  Portions created by Shariq Muhammad
are Copyright (C) Shariq Muhammad. All Rights Reserved.

Contributor(s): Shariq Muhammad <shariq.muhammad@gmail.com>
                Yuri Astrakhan <FirstName><LastName>@gmail.com
*/
using System;
using OpenFAST.Template.Operators;
using OpenFAST.Template.Types.Codec;

namespace OpenFAST.Template.Types
{
    public class StringType : SimpleType
    {
        public StringType(string typeName, TypeCodec codec, TypeCodec nullableCodec)
            : base(typeName, codec, nullableCodec)
        {
        }

        public override ScalarValue DefaultValue
        {
            get { return new StringValue(""); }
        }

        public override ScalarValue GetVal(string value)
        {
            return new StringValue(value);
        }

        public override TypeCodec GetCodec(Operator op, bool optional)
        {
            if (op == Operator.Delta)
                return optional ? TypeCodec.NullableStringDelta : TypeCodec.StringDelta;

            return base.GetCodec(op, optional);
        }

        public override bool IsValueOf(ScalarValue priorValue)
        {
            return priorValue is StringValue;
        }
    }
}