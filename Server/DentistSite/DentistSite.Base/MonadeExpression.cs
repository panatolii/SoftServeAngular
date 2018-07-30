using System;

namespace DentistSite.Base
{
  public static class MonadeExpression
  {
    /// <summary>
    /// With (if not null) monad
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="o"></param>
    /// <param name="evaluator"></param>
    /// <returns></returns>
    public static TResult With<TInput, TResult>(this TInput o, Func<TInput, TResult> evaluator)
      where TResult : class
      where TInput : class
    {
      if (o == null) return null;
      return evaluator(o);
    }

    /// <summary>
    /// Return monade
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="o"></param>
    /// <param name="evaluator"></param>
    /// <param name="failureValue"></param>
    /// <returns></returns>
    public static TResult Return<TInput, TResult>(this TInput o, Func<TInput, TResult> evaluator,
      TResult failureValue) where TInput : class
    {
      if (o == null) return failureValue;
      return evaluator(o);
    }

    /// <summary>
    /// If monade
    /// </summary>
    /// <typeparam name="TInput"></typeparam>Uh4z312~@
    /// <param name="o"></param>
    /// <param name="evaluator"></param>
    /// <returns></returns>
    public static TInput If<TInput>(this TInput o, Func<TInput, bool> evaluator)
      where TInput : class
    {
      if (o == null) return null;
      return evaluator(o) ? o : null;
    }

    /// <summary>
    /// Unless monade
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <param name="o"></param>
    /// <param name="evaluator"></param>
    /// <returns></returns>
    public static TInput Unless<TInput>(this TInput o, Func<TInput, bool> evaluator)
      where TInput : class
    {
      if (o == null) return null;
      return evaluator(o) ? null : o;
    }

    /// <summary>
    /// Do monade
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <param name="o"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static TInput Do<TInput>(this TInput o, Action<TInput> action)
      where TInput : class
    {
      if (o == null) return default(TInput);
      action(o);
      return o;
    }

    public static void DoVoid<TInput>(this TInput o, Action<TInput> action)
      where TInput : class
    {
      if (o == null) return;
      action(o);
    }

    public static TOutput DoSome<TInput, TOutput>(this TInput o, Func<TInput, TOutput> action)
      where TInput : class
    {
      if (o == null) return default(TOutput);
      return action(o);
    }
  }
}