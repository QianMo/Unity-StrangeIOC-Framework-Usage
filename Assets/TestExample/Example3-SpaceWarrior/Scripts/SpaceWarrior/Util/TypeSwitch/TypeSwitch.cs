using System;

/// http://stackoverflow.com/questions/298976/is-there-a-better-alternative-than-this-to-switch-on-type
/// http://stackoverflow.com/a/299120

/// <summary>
/// Switching On Types in C#
/// 
/// Usage:
/// 
/// TypeSwitch.Do(
/// 	sender,
/// 	TypeSwitch.Case<Button>(() => textBox1.Text = "Hit a Button"),
///		TypeSwitch.Case<CheckBox>(x => textBox1.Text = "Checkbox is " + x.Checked),
///		TypeSwitch.Default(() => textBox1.Text = "Not sure what is hovered over.")
///	);
/// </summary>

static class TypeSwitch
{
	public class CaseInfo
	{
		public bool IsDefault { get; set; }
		public Type Target { get; set; }
		public Action<object> Action { get; set; }
	}

	public static void Do(object source, params CaseInfo[] cases)
	{
		var type = source.GetType();
		foreach (var entry in cases)
		{
			if (entry.IsDefault || entry.Target.IsAssignableFrom(type))
			{
				entry.Action(source);
				break;
			}
		}
	}

	public static CaseInfo Case<T>(Action action)
	{
		return new CaseInfo() {
			Action = x => action(),
			Target = typeof(T)
		};
	}

	public static CaseInfo Case<T>(Action<T> action)
	{
		return new CaseInfo() {
			Action = (x) => action((T)x),
			Target = typeof(T)
		};
	}

	public static CaseInfo Default(Action action)
	{
		return new CaseInfo() {
			Action = x => action(),
			IsDefault = true
		};
	}
}
