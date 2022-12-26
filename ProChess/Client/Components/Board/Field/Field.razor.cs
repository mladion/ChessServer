using System;
using Microsoft.AspNetCore.Components;

namespace Client.Components.Board.Field
{
	public partial class Field
	{
        [Parameter]
        public int FieldColor { get; set; }
    }
}

