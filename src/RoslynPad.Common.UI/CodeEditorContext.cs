using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoslynPad.Roslyn;

namespace RoslynPad.UI
{
	public class CodeEditorContext
	{
		public RoslynHost RoslynHost { get; }

		public NuGetConfiguration NuGetConfiguration { get; }

		public double MinEditorFontSize { get; }
        public double MaxEditorFontSize { get; }

		private double _editorfontSize;
		public double EditorFontSize {
			get => _editorfontSize;
			set {
				var newVal = Math.Max(Math.Min(value, MaxEditorFontSize), MinEditorFontSize);

				if (value != _editorfontSize) {
					_editorfontSize = value;
					EditorFontSizeChanged?.Invoke(value);
				}
			}
		}
		public event Action<double> EditorFontSizeChanged;

		public CodeEditorContext(RoslynHost roslynHost, NuGetConfiguration nuGetConfiguration, double minEditorFontSize, double maxEditorFontSize, double editorFontSize)
		{
			this.RoslynHost = roslynHost ?? throw new ArgumentNullException(nameof(roslynHost));
			this.NuGetConfiguration = nuGetConfiguration ?? throw new ArgumentNullException(nameof(nuGetConfiguration));

			this.MinEditorFontSize = minEditorFontSize;
			this.MaxEditorFontSize = maxEditorFontSize;
			this.EditorFontSize = editorFontSize; //Clips values automatically, event is null at this point


		}
	}
}
